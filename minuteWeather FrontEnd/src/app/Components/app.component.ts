import {Component, NgModule} from '@angular/core';
import { MatSliderModule } from '@angular/material/slider';

@NgModule({
  imports: [
    MatSliderModule,
  ]
})
class AppModule {}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'minuteWeather';
}


