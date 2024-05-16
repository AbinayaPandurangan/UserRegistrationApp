function isNameValid(name: string) {
  if (/^[a-zA-Z]+$/.test(name) && name.length > 1) {
    return true;
  } else {
    return false;
  }
}

function isEmailValid(email: string) {
  if (/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(email)) {
    return true;
  } else {
    return false;
  }
}

function isPhoneNoValid(phoneNo: string) {
  if (/^\d+$/.test(phoneNo) && phoneNo.length == 9) {
    return true;
  } else {
    return false;
  }
}

export { isNameValid, isEmailValid, isPhoneNoValid };
