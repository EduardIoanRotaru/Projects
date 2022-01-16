import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TodayTasksComponent } from './components/today-tasks/today-tasks.component';
import { UpcomingTasksComponent } from './components/upcoming-tasks/upcoming-tasks.component';
import { LoginComponent } from './components/user-account/login/login.component';
import { RegisterComponent } from './components/user-account/register/register.component';
import { AuthGuard } from './shared/guards/auth.guard';

const routes: Routes = [
  { path: '', component: TodayTasksComponent },
  { path: 'today-tasks', component: TodayTasksComponent },
  { path: 'upcoming-tasks', component: UpcomingTasksComponent, canActivate: [AuthGuard] },
  { path: 'projects', loadChildren: () => import('./components/projects/projects.module').then(m => m.ProjectsModule)},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }