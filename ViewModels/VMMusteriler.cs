﻿using System.Data;

namespace B2B_Deneme.ViewModels
{
    public class VMMusteriler
    {
        public List<DataRow> Musteriler { get; set; } = new List<DataRow>();
        public List<DataRow> Stoklar { get; set; } = new List<DataRow>();

    }
}