﻿using DevOps.DataAccess.AppService.Interfaces;
using DevOps.Models.AppModel;
using DevOps.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOps.DataAccess.AppService.Implementation
{
    public class CustomerService : ICustomerService
    {

        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<Customer>> AddCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            SaveChanges();
            return new ApiResponse<Customer> { StatusCode = 200, IsSuccess = true, Message = "Customer added successfully", Response = null };
        }

        public Task<ApiResponse<bool>> DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<Customer>>> GetAllCustomer()
        {
            var customers = await _context.Customers.ToListAsync();
            
            return new ApiResponse<List<Customer>> { IsSuccess = true, Message = "Customer List", StatusCode = 200, Response = customers };
        }

        public Task<ApiResponse<Customer>> GetCustomerById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Customer>> UpdateCustomer(Project project)
        {
            throw new NotImplementedException();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
