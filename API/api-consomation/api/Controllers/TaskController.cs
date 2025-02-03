using apiExo.bll.entity;
using apiExo.bll.services;
using Microsoft.AspNetCore.Mvc;

namespace apiExo.controllers;

public class TaskController(ITaskService ts) : ControllerBase
{

    [HttpGet]
    public ActionResult All()
    {
        var tasks = ts.GetAll();
        return Ok(tasks);
    }


    [HttpGet]
    public ActionResult GetById([FromQuery] int id)
    {
        var task = ts.GetByID(id);
        return task != null ? Ok(task) : NotFound($"Task with ID {id} not found.");
    }

    [HttpPost]
    public ActionResult Add([FromBody] TaskModel model)
    {
        var task = new TaskEntity
        {
            Title = model.Title,
            Status = model.Status
        };

        string result = ts.Add(task);
        return Ok(result);
    }

    [HttpPut]
    public ActionResult Update([FromBody] TaskUpdate model)
    {
        string result = ts.Update(model);
        return Ok(result);
    }

    [HttpPatch]
    public ActionResult Patch([FromBody] TaskPatch model)
    {
        string result = ts.Patch(model);
        return Ok(result);
    }
}