import { Component, OnInit } from '@angular/core';
import {Server} from '../../shared/server';
const SAMPLE_SERVERS = [
  {id:1, name: 'dev-web', isOnline: true},
  {id:2, name: 'dev-mail', isOnline: false},
  {id:3, name: 'dev-web2', isOnline: true},
  {id:4, name: 'dev-mail2', isOnline: true}
];
@Component({

 
  selector: 'app-section-health',
  templateUrl: './section-health.component.html',
  styleUrls: ['./section-health.component.css']
})
export class SectionHealthComponent implements OnInit {

  constructor() { }
  servers: Server[] = SAMPLE_SERVERS;

  ngOnInit(): void {
  }

}
