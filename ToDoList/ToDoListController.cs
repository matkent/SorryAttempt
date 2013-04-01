using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core.Continuations;

namespace ToDoList
{
	public class ToDoListController
	{
		private int _lastId;
		private ToDoListViewModel _model;

		public static string SessionKey = "ToDoListSession";

		public ToDoListViewModel ToDoList()
		{
			_model = (ToDoListViewModel)HttpContext.Current.Session[SessionKey] ?? new ToDoListViewModel();

			return _model;
		}

		public void post_addToDoWithDescription_Description(ToDoModel toDo)
		{
			_model.ToDos.Add(new ToDoModel { Id = GetId(), Description = toDo.Description });
		}

		public void get_removeToDoWithId_Id(ToDoModel toDo)
		{
			var toRemove = _model.ToDos.Find(x => x.Id == toDo.Id);
			_model.ToDos.Remove(toRemove);
		}

		private int GetId()
		{
			return ++_lastId;
		}
	}

	public class ToDoListViewModel
	{
		private List<ToDoModel> _toDos;
		public List<ToDoModel> ToDos
		{
			get { return _toDos ?? new List<ToDoModel>(); }
			set { _toDos = value; }
		}
	}

	public class ToDoModel
	{
		public int Id { get; set; }
		public string Description { get; set; }
	}
}