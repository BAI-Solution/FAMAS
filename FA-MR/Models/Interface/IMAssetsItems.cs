using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA_MR.Models.Interface
{
    public interface IMAssetsItems
    {
        /// <summary>
        /// To binding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        AssetItem ToBinding(MAssetsItems pObj);
        /// <summary>
        /// To binding
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        IList<AssetItem> ToBinding(IList<MAssetsItems> pObj);
        /// <summary>
        /// To view model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        MAssetsItems ToModel(AssetItem pObj);
        /// <summary>
        /// To view model
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        IList<MAssetsItems> ToModel(IList<AssetItem> pObj);
    }
}
