using System.Collections.Generic;
using Pgmasst.Main.Pginfos;

namespace Pgmasst.WebApi
{
    public interface IModelSpawnInfo
    {
        IEnumerable<Sprite> GetCurrentSprites(string since, IEnumerable<int> ids);
    }
}