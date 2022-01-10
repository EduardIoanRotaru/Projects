import { HttpClient } from '@angular/common/http';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { IQuestion } from '../shared/models/IQuestion';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss']
})
export class QuizComponent implements OnInit {
  questions: IQuestion[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<IQuestion[]>("https://localhost:44302/api/question").subscribe(q => {
      this.questions = q;
    });
  }
}
