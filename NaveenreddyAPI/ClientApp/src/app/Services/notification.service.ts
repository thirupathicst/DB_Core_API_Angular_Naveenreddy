import { Injectable } from '@angular/core';
declare let toastr: any;

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor() {
    toastr.options = {
      "closeButton": false,
      //"debug": false,
      "newestOnTop": false,
      "progressBar": true,
      "positionClass": "toast-top-right",
      "preventDuplicates": false,
     // "onclick": null,
      "showDuration": "300",
      "hideDuration": "1000",
      "timeOut": "5000",
      "extendedTimeOut": "1000",
      //"showEasing": "swing",
      //"hideEasing": "linear",
      "showMethod": "fadeIn",
      "hideMethod": "fadeOut"
    }
   }

  showSuccess(message, title="Success") {
    toastr.success(message, title)
  }

  showError(message, title="Error") {
    toastr.error(message, title)
  }

  showInfo(message, title="Info") {
    toastr.info(message, title)
  }

  showWarning(message, title="Warning") {
    toastr.warning(message, title)
  }

}
