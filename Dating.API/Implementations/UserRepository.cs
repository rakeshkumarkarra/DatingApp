using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dating.API.DTOs;
using Dating.API.Interfaces;
using Dating.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.API.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly DatingAppContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DatingAppContext context,
                              IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.AppUsers
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<List<MemberDto>> GetMembersAsync()
        {
            return await _context.AppUsers
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.AppUsers.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.AppUsers.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            return await _context.AppUsers.Include(p => p.Photos).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
