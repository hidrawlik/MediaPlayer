using BlazorUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUI.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumViewModel>> GetAlbumsAsync();
    }
}
