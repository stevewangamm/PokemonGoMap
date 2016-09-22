using System.Collections.Generic;
using Pgmasst.Main.Pginfos;

namespace Pgmasst.Api
{
    public interface IModelSpawnInfo
    {
        IEnumerable<Sprite> GetCurrentSprites(string since, IEnumerable<int> ids);
    }
}