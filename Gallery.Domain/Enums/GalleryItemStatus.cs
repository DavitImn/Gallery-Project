using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Domain.Enums
{
    public enum GalleryItemStatus : byte
    {
        Deleted = 0,
        Draft = 1,
        Published = 2
    }
}
