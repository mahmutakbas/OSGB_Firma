﻿using System;

namespace Entities.Concrete.Data
{
    public class Randevu : BaseEntity
    {
        public int YurutucuFirmaId { get; set; }
        public string Aciklama { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public bool Onay { get; set; }
    }
}
