import { Injectable } from '@angular/core';
import Swal, { SweetAlertInput } from 'sweetalert2';
@Injectable()
export class SwalService {
  showError(title: string, text: string) {
    Swal.fire({
      icon: 'error',
      title: title,
      text: text,
    });
  }

  showSuccess(title: string, text: string) {
    Swal.fire({
      icon: 'success',
      title: title,
      text: text,
    });
  }

  optionSwal(
    title: string,
    text: string,
    cancelText: string,
    confirmText: string,
    dennyText: string
  ) {
    return Swal.fire({
      title: title,
      text: text,
      showDenyButton: dennyText != '',
      showCancelButton: cancelText != '',
      showConfirmButton: confirmText != '',

      confirmButtonText: confirmText,
      denyButtonText: dennyText,
      cancelButtonText: cancelText,
    });
  }

  htmloptionSwal(
    title: string,
    htmltext: string,
    cancelText: string,
    confirmText: string,
    dennyText: string,
    useInput: SweetAlertInput | null
  ) {
    if (useInput)
      return this.htmloptionSwalAux(
        title,
        htmltext,
        cancelText,
        confirmText,
        dennyText,
        useInput
      );
    else
      return this.htmloptionSwalAuxWithoutInput(
        title,
        htmltext,
        cancelText,
        confirmText,
        dennyText
      );
  }

  private htmloptionSwalAux(
    title: string,
    htmltext: string,
    cancelText: string,
    confirmText: string,
    dennyText: string,
    inputType: SweetAlertInput
  ) {
    return Swal.fire({
      title: title,
      html: htmltext,
      input: inputType,
      showDenyButton: dennyText != '',
      showCancelButton: cancelText != '',
      showConfirmButton: confirmText != '',
      confirmButtonText: confirmText,
      denyButtonText: dennyText,
      cancelButtonText: cancelText,
    });
  }

  private htmloptionSwalAuxWithoutInput(
    title: string,
    htmltext: string,
    cancelText: string,
    confirmText: string,
    dennyText: string
  ) {
    return Swal.fire({
      title: title,
      html: htmltext,
      showDenyButton: dennyText != '',
      showCancelButton: cancelText != '',
      showConfirmButton: confirmText != '',
      confirmButtonText: confirmText,
      denyButtonText: dennyText,
      cancelButtonText: cancelText,
    });
  }
}
