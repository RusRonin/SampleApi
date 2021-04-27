import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

class ToDoItem {
  id: number | undefined;
  name: string;
  done: boolean;
  constructor(name: string) {
    this.name = name;
    this.done = false;
  }
}


@Component({
  selector: 'app-todo-app',
  templateUrl: './todo-app.component.html',
  styleUrls: ['./todo-app.component.css']
})
export class TodoAppComponent implements OnInit {
  newToDo = '';
  todos: ToDoItem[] = [];
  private _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  async ngOnInit() {
    this.todos = await this._http.get<ToDoItem[]>("/api/todo").toPromise();
  }

  async addTodoHandler() {
    let newToDo: ToDoItem = new ToDoItem(this.newToDo);
    let newToDoId: number = await this._http.post<number>("/api/todo", newToDo).toPromise();
    newToDo.id = newToDoId;
    this.todos.push(newToDo);
    this.newToDo = '';
  }

  async updateTodoHandler(todo: ToDoItem) {
    console.log(todo.id);
    console.log(todo.name);
    await this._http.put("/api/todo", todo).toPromise();
  }
}
