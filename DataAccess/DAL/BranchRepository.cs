using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;
using System.Linq;

namespace DAL
{
    public class BranchRepository : IBranchRepository
    {
        private readonly MySalonDbContext _context;

        public BranchRepository(MySalonDbContext dbContext)
        {
            _context = dbContext;
        }
        public Branch CreateBranch(Branch branch)
        {
            _context.Branches.Add(branch);
            _context.SaveChanges();
            return branch;
        }

        public List<Branch> GetAllBranches()
        {
            return _context.Branches.ToList();
        }

        public Branch GetBranch(int id)
        {
            return _context.Branches.Find(id);
        }
    }
}
