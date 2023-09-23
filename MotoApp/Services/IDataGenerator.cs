using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.Services;

public interface IDataGenerator
{
    public void AddCars();
    public void GenerateAndAddSampleCars();
}
