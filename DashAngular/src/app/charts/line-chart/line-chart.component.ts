import { Component, OnInit } from '@angular/core';
import {LINE_CHART_COLORS} from '../../shared/chart.colors';
const LINE_CHART_SAMPLE_DATA: any[] = [
  {data: [32,14,46,23,38,56], label: 'Sentiment Analysis'},
  {data: [19, 21,36,13,28,36], label: 'Image Recoginition'},
  {data: [52,17,23,13,67,63], label: 'Forecasting'}
];
const LINE_CHART_LABELS: string[] = ['Jan', 'Fab', 'Mar', 'Apr', 'May', 'Jun'];

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {

  constructor() { }
public lineChartData = LINE_CHART_SAMPLE_DATA;
public lineChartLabels = LINE_CHART_LABELS;
public lineChartOptions: any = {
 responsive: true
};
lineChartLegend: true;
lineChartType = 'line';
lineChartColors = LINE_CHART_COLORS;
  ngOnInit(): void {
  }

}
