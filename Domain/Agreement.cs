﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseService.Legacy.Domain
{
    public class Agreement
    {
        public string AgreementID { get; set; } 

        public int AllocatedLicenseCount { get; set; }

        public int LicenseCount { get; set; }


    }
}
