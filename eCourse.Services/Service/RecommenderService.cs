using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.Recommender;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCourse.Services.Service
{
    public class RecommenderService
    {
        static MLContext mlContext = null;
        static ITransformer model = null;

        public static List<KursInstanca> GetRecommended(CourseContext _context, int klijentId)
        {
            try
            {
                /*
                1 skupiti sve: userid, kursid, rejting
                2ubacujes za kurs id koji je korisnik vec ocjenio i tako
                dobijas za tog klijenta kurseve sa najvecim ocjenama
                3uzmes top 3
                4trazis 3 aktivna kursa tj 3 instance
                i vratis, end
                =trazi 3 preporucena kursa za klijenta na osnovu prethodno ocijenjenih
                train se poziva samo jednom tako da za nove klijente nece raditi
                dovoljno za sad
                 */
                if (mlContext == null)
                {
                    mlContext = new MLContext();
                    var tmpData = _context.KlijentKursInstanca
                        .Include(k => k.KursInstanca)
                            .ThenInclude(kk => kk.Kurs)
                        .Where(k => k.Rejting != null)
                        .ToList();
                    //IDataView trainingDataView = mlContext.Data.LoadFromTextFile<KursRejting>(TrainingDataLocation, hasHeader: true, ar: ',');
                    var dataList = new List<KursRejting>();
                    foreach(var x in tmpData)
                    {
                        dataList.Add(new KursRejting
                        {
                            kursId = x.KursInstanca.Kurs.Id,
                            userId = x.KlijentId,
                            Label = (int)x.Rejting
                        });
                    }
                    var trainingDataView = mlContext.Data.LoadFromEnumerable(dataList);

                    var dataProcessingPipeline = mlContext
                        .Transforms
                        .Conversion
                        .MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: nameof(KursRejting.userId))
                        .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "kursIdEncoded", inputColumnName: nameof(KursRejting.kursId)));

                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = "userIdEncoded";
                    options.MatrixRowIndexColumnName = "kursIdEncoded";
                    options.LabelColumnName = "Label";
                    options.NumberOfIterations = 20;
                    options.ApproximationRank = 100;

                    var trainingPipeLine = dataProcessingPipeline.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));

                    model = trainingPipeLine.Fit(trainingDataView);

                    //var prediction = model.Transform(testDataView);
                    //var metrics = mlContext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");

                    //var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "MovieRecommenderModel.zip");
                    //Console.WriteLine("=============== Saving the model to a file ===============");
                    //mlContext.Model.Save(model, trainingDataViewSchema, modelPath);
                }
                var sviNadolazeciKursevi = _context.KursInstanca
                    .Include(k => k.Kurs) // Includan jer treba nakon obrade u servicu zbog naziv kursa
                    .Where(k => k.PrijaveDoDatum.Date >= DateTime.Now.Date && k.KrajDatum==null)
                    .ToList();
                var prijavljeniKursevi = _context
                    .KlijentKursInstanca
                    .Where(k => k.KlijentId == klijentId)
                    .Select(p => p.KursInstancaId)
                    .ToList();

                var scoreData = new List<Tuple<KursInstanca, float>>();
                foreach(var kursInstaca in sviNadolazeciKursevi)
                {
                    if (prijavljeniKursevi.Contains(kursInstaca.Id)) continue; // Izbjegavam već prijavljene kurseve
                    var predictionEngine = mlContext.Model.CreatePredictionEngine<KursRejting, KursRatingPrediction>(model);
                    var prediction = predictionEngine.Predict(new KursRejting
                    {
                        kursId = kursInstaca.KursId,
                        userId = klijentId
                    });
                    //You can then use the Score, or the predicted rating, to 
                    //determine whether you want to recommend the movie with movieId 
                    //    10 to user 6. The higher the Score, the higher the 
                    //    likelihood of a user liking a particular movie.
                    scoreData.Add(new Tuple<KursInstanca, float>(
                        kursInstaca,
                        prediction.Score
                    ));
                }
                var finalResult = scoreData.OrderByDescending(x => x.Item2).Take(3).Select(x => x.Item1).ToList();
                //if(finalResult.Count<3 && sviNadolazeciKursevi.Count >= 3)
                //{
                //    var instanceSaKlijentimaList = _context.KursInstanca
                //        .Include(k => k.KlijentiNaKursu)
                //        .Include(k => k.Kurs)
                //        .Where(k => k.PrijaveDoDatum.Date >= DateTime.Now.Date)
                //        //.OrderByDescending(k => k.KlijentiNaKursu.Count)
                //        //.Take(3)
                //        .ToList();
                //    var instanceSaKlijentima = instanceSaKlijentimaList
                //        .OrderByDescending(k => k.KlijentiNaKursu.Count)
                //        .Take(3)
                //        .ToList();
                //    for (int i = 0; finalResult.Count != 3; i++)
                //    {
                //        bool vecSadrzan = false;
                //        foreach(var x in finalResult)
                //        {
                //            if(x.Id == instanceSaKlijentima[i].Id)
                //            {
                //                vecSadrzan = true;
                //                break;
                //            }
                //        }
                //        if(!vecSadrzan) finalResult.Add(instanceSaKlijentima[i]);
                //    }
                //} // ovo se ipak ne desi nikad, svi kursevi se ubace a score bude NaN ako nema podataka
                return finalResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
