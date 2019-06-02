﻿using System;

namespace TfsDeployer.Data
{
    [Serializable]
    public class QueuedDeployment
    {
        public int Id { get; set; }
        public string Script { get; set; }
        public string Queue { get; set; }
        public DateTime QueuedUtc { get; set; }
        public DateTime? StartedUtc { get; set; }
        public DateTime? FinishedUtc { get; set; }
        public bool HasErrors { get; set; }
    }
}