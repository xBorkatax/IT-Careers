﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GuideToFlavors.Areas.Identity.Data;

public class GuideToFlavorsUser : IdentityUser
{
	[PersonalData]
	public string FirstName { get; set; }

	[PersonalData]
	public string LastName { get; set; }
}

