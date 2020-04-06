import { Component, OnInit } from '@angular/core';
import {Server} from '../../shared/server';
import {Observable, timer} from 'rxjs';
import { ServerMessage } from '../../shared/server-message';

import {ServerService} from '../../services/server.service';
import { ThrowStmt } from '@angular/compiler';
//const SAMPLE_SERVERS = [
//  {id:1, name: 'dev-web', isOnline: true},
//  {id:2, name: 'dev-mail', isOnline: false},
//  {id:3, name: 'dev-web2', isOnline: true},
//  {id:4, name: 'dev-mail2', isOnline: true}
//];
@Component({

 
  selector: 'app-section-health',
  templateUrl: './section-health.component.html',
  styleUrls: ['./section-health.component.css']
})
export class SectionHealthComponent implements OnInit {

  constructor(private _serverService: ServerService) { }
  servers: Server[];
  timerSubscription: Observable<number> =timer(5000);

  ngOnInit(): void {
    this.refreshData();
    this._serverService.getServers().subscribe(res => {
      this.servers = res;
    })
  }
  refreshData() {
    this._serverService.getServers().subscribe(res => {
      this.servers = res;
    });

    this.subscribeToData();
  }

  subscribeToData() {
    this.timerSubscription.subscribe(() => this.refreshData());
  }


}
