﻿namespace Domain.Entities
{
    public class CampaignTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Projects> Projects { get; set; }
    }
}
