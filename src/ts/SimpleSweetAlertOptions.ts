import {
  SweetAlertCustomClass,
  SweetAlertIcon,
  SweetAlertShowClass,
  SweetAlertHideClass,
  SweetAlertInput,
  SweetAlertPosition
} from "sweetalert2";
import { SweetAlertGrow } from "./SweetAlertGrow";

export default interface SimpleSweetAlertOptions {
  title?: string;

  titleText?: string;

  text?: string;

  html?: string;

  footer?: string;

  icon?: SweetAlertIcon;

  iconHtml?: string;

  backdrop?: boolean;

  toast?: boolean;

  target?: string;

  input?: SweetAlertInput;

  width?: string;

  padding?: string;

  background?: string;

  position?: SweetAlertPosition;

  grow?: SweetAlertGrow;

  showClass?: SweetAlertShowClass;

  hideClass?: SweetAlertHideClass;

  customClass?: SweetAlertCustomClass;

  timer?: number;

  timerProgressBar?: boolean;

  heightAuto?: boolean;

  allowOutsideClick?: boolean;

  allowEscapeKey?: boolean;

  allowEnterKey?: boolean;

  stopKeydownPropagation?: boolean;

  keydownListenerCapture?: boolean;

  showConfirmButton?: boolean;

  showCancelButton?: boolean;

  confirmButtonText?: string;

  cancelButtonText?: string;

  confirmButtonColor?: string;

  cancelButtonColor?: string;

  confirmButtonAriaLabel?: string;

  cancelButtonAriaLabel?: string;

  buttonsStyling?: boolean;

  reverseButtons?: boolean;

  focusConfirm?: boolean;

  focusCancel?: boolean;

  showCloseButton?: boolean;

  closeButtonHtml?: string;

  closeButtonAriaLabel?: string;

  showLoaderOnConfirm?: boolean;

  preConfirm: boolean;

  imageUrl?: string;

  imageWidth?: number;

  imageHeight?: number;

  imageAlt?: string;

  imageClass?: string;

  inputPlaceholder?: string;

  inputValue?: string;

  inputOptions?: Map<string, string>;

  inputAutoTrim?: boolean;

  inputAttributes?: Map<string, string>;

  inputValidator: boolean;

  validationMessage?: string;

  inputClass?: string;

  progressSteps?: string[];

  currentProgressStep?: string;

  progressStepsDistance?: string;

  onBeforeOpen: boolean;

  onAfterClose: boolean;

  onDestroy: boolean;

  onOpen: boolean;

  onClose: boolean;

  onRender: boolean;

  scrollbarPadding?: boolean;
}
