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
            { //ako nema dovoljno dodaj 3 aktivna kursa sa najvise klijenata
                if (mlContext == null)
                {
                    mlContext = new MLContext();
                    var tmpData = _context.KlijentKursInstanca
                        .Include(k => k.KursInstanca)
                            .ThenInclude(kk => kk.Kurs)
                        .Where(k => k.Rejting != null)
                        .ToList();
                    IDataView trainingDataView = mlContext.Data.LoadFromTextFile<KursRejting>(TrainingDataLocation, hasHeader: true, ar: ',');

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
                }


                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
