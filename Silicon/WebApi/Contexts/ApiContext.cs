﻿using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Contexts;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<SubscribeEntity> Subscribers { get; set; }
}