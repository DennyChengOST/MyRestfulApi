using System;

namespace MyRetailService.Interfaces.Repositories
{
    public interface IRedSkyRepository
    {
        string GetProductName(Int64 id);
    }
}
