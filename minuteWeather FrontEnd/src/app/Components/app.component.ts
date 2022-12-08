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
  myImage:string = this.ImagePath();

  ImagePath()
  {
    let backgroundImage:string = "../../assets/Images/";
    let randInt:number = Math.floor(Math.random() * 8);
    
    switch(randInt)
    {
      case 0:
        backgroundImage += "Sunny.jpg";
        break;
      case 1:
        backgroundImage += "Cloudy.jpg";
        break;
      case 2:
        backgroundImage += "Rainy.jpg";
        break; 
      case 3:
        backgroundImage += "Windy.jpg";
        break;
      case 4:
        backgroundImage += "Snowy.jpg";
        break;
      default:
        backgroundImage += "Sunny.jpg";
        break;
    }
    
    return backgroundImage;
  }

  constructor(private backend: BackendCallsService)
  {
    let randInt:number = Math.floor(Math.random() * 8);
    
    
    
  }

  sendVerification()
  {
    this.backend.sendVerification("");
  }
}

