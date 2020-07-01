using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Recommender
{
    public class KursRejting
    {
        [LoadColumn(0)]
        public float userId;

        [LoadColumn(1)]
        public float kursId;

        [LoadColumn(2)]
        public float Label;
    }

    public class KursRatingPrediction
    {
        public float Label;
        public float Score;
    }
}
