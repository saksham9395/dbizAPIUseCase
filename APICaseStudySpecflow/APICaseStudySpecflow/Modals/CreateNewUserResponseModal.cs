﻿using System;
using System.Collections.Generic;
using System.Text;

namespace APICaseStudySpecflow.Modals
{

    public class CreateNewUserModalResponse
    {
        public string name { get; set; }
        public string job { get; set; }
        public string id { get; set; }
        public DateTime createdAt { get; set; }
    }

    public class CreateNewUserModalRequest
    {
        public string name { get; set; }
        public string job { get; set; }
    }

}
