﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - RadioRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/01
// ==================================

namespace AutoLot.Dal.Repos;

public class RadioRepo : TemporalTableBaseRepo<Radio>, IRadioRepo
{
    public RadioRepo(ApplicationDbContext context) : base(context) { }
    internal RadioRepo(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}