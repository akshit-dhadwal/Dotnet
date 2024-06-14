using DataLayer.ContextFiles;
using DataLayer.InterfaceRepositories;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DBOperations.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context) : base(context)
        {
           _context = context;
        }
    }
}
