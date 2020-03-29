import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-select-teams',
  templateUrl: './select-teams.component.html',
  styleUrls: ['./select-teams.component.css']
})
export class SelectTeamsComponent implements OnInit {
  title = 'Zone 1';
  submitted = false;

  constructor() { }

  goToNextStep() {
    this.submitted = true;
  }

  ngOnInit() {
  }

}
