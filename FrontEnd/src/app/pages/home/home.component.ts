import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/Task';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { Dialog } from '@angular/cdk/dialog';
import { ExcluirComponent } from '../../components/excluir/excluir.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  
  taskForm!: FormGroup;
  
  tasks: Task[] = [];

  columnsToDisplay = ['Descricao','Status','Acoes']

  constructor( private taskService: TaskService, private location: Location, public dialog: Dialog) {}

  ngOnInit(): void {

    this.taskService.GetTasks().subscribe(data => {
      const dados = data.data;
      
      dados.map((item) => {
        item.dtTask = new Date(item.dtTask!).toLocaleDateString('pt-BR')
        item.dtCreation = new Date(item.dtCreation!).toLocaleDateString('pt-BR')
        item.dtModification = new Date(item.dtModification!).toLocaleDateString('pt-BR')
      })
              
      this.tasks = data.data;
    });

    this.taskForm = new FormGroup({
      idTask: new FormControl(0),
      strDescription: new FormControl('', [Validators.required]),
      dtTask: new FormControl('', [Validators.required]),
      dtCreation: new FormControl(new Date()),
      dtModification: new FormControl(new Date())
    }); 
  }

  onSubmit(){
    this.taskService.CreateTask(this.taskForm.value).subscribe(
      sucess => {
        console.log('sucesso');
        this.ngOnInit();
      },
      error => console.log(error),
      () => console.log('resquest completo')
    );
  }
  submit(){
    console.log(this.taskForm.value);
    this.onSubmit();
  }

  OpenDialog(){
    this.dialog.open(ExcluirComponent, {
      width: '350px',
      height: '350px'
    });
  }


}
