import {Component, NgModule} from '@angular/core';
import { MatSliderModule } from '@angular/material/slider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BackendCallsService } from './Backend-calls/backend-calls.service';
import {FormControl, Validators} from '@angular/forms';


@NgModule({
  imports: [
    MatSliderModule,
    MatFormFieldModule,
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

  constructor(private backend: BackendCallsService){}

  sendVerification()
  {
    this.backend.sendVerification("");
  }
}

