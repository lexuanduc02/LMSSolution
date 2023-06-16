﻿using AutoMapper;
using LMSSolution.Application.Course;
using LMSSolution.ViewModels.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
        }

        //https://localhost:<port>/users/paging?pageIndex=1&pagesize=10
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetCoursePagingRequest request)
        {
            var users = await _courseService.GetAllCoursePaging(request);
            return Ok(users.ResultObject);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CourseCreateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseService.Create(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromForm] CourseEditRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseService.Edit(request);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] CourseDeleteRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _courseService.Delete(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
