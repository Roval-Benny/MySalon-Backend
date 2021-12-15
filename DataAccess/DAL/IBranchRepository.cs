using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;

namespace DAL
{
    public interface IBranchRepository
    {
        List<Branch> GetAllBranches();
        Branch GetBranch(int id);
        Branch CreateBranch(Branch branch);
    }
}
