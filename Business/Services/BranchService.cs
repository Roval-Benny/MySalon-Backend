using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;
using DAL;
using Exceptions;

namespace Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _repository;
        public BranchService(IBranchRepository repo)
        {
            _repository = repo;
        }
        public Branch CreateBranch(Branch branch)
        {
            return _repository.CreateBranch(branch);
        }
        public Branch GetBranchById(int id)
        {
            if (_repository.GetBranch(id) != null)
            {
                return _repository.GetBranch(id);
            }
            else
            {
                throw new BranchNotFoundException($"Branch with id: {id} does not exist");
            }
        }
        public List<Branch> GetAllBranch()
        {
            return _repository.GetAllBranches();
        }
    }
}
