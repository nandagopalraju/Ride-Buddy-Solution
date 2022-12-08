using RB.Core.Application.DTO;
using RB.Core.Application.Interface;
using RB.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.Repository.User
{
    public class HostAcceptService : IHostAcceptService
    {
        private readonly UserDbContext _userDbContext;
        public HostAcceptService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public void HostAccept(List<int> id)
        {
            List<JoinRide> joinreq;
            for(int i =0; i<id.Count;i++)
            {
                joinreq = _userDbContext.JoinRide.Where(x => x.HostedRidesId == id[i]).ToList();
                joinreq[i].Status = true;
                _userDbContext.Update(joinreq[i]);
                _userDbContext.SaveChangesAsync();

            }
            
            

        }
    }
}
