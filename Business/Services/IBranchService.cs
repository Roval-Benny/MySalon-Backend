using MySalonModels;
using System.Collections.Generic;

namespace Services
{
    public interface IBranchService
    {
        Branch CreateBranch(Branch branch);
        List<Branch> GetAllBranch();
        Branch GetBranchById(int id);
        
    }
}