import { ChangeEvent, useState } from "react";
import { UserRegistrationFormData } from "../models/FormDataModal";
import {
  isNameValid,
  isPhoneNoValid,
  isEmailValid,
} from "../utils/ValidationUtils";

interface Props {
  submitForm: (formData: UserRegistrationFormData) => void;
}

function RegistrationPage(props: Props) {
  const defaultInputElementState = { value: "", isTouched: false }
  const [userName, setUserName] = useState(defaultInputElementState);
  const [dob, setDob] = useState(defaultInputElementState);
  const [email, setEmail] = useState(defaultInputElementState);
  const [phoneNo, setPhoneNo] = useState(defaultInputElementState);
  const [genderId, setGenderId] = useState(0);

  const maxDate = () => {
    const today = new Date().toISOString().split("T")[0];
    return today;
  };

  const getIsFormValid = () => {
    return (
      isNameValid(userName.value) &&
      dob.value != "" &&
      isEmailValid(email.value) &&
      isPhoneNoValid(phoneNo.value) &&
      genderId != 0
    );
  };

  function setGenderIdHandler(e: ChangeEvent<HTMLInputElement>) {
    setGenderId(parseInt(e.target.value));
  }

  function clearForm() {
    setDob(defaultInputElementState);
    setEmail(defaultInputElementState);
    setUserName(defaultInputElementState);
    setGenderId(0);
    setPhoneNo(defaultInputElementState);
  }

  const handleSubmit = (e: { preventDefault: () => void }) => {
    e.preventDefault();
    const formData = {
      userName: userName.value,
      email: email.value,
      phoneNo: phoneNo.value,
      dob: dob.value,
      genderId: genderId,
    };
    props.submitForm(formData);
    clearForm();
  };

  return (
    <>
      <div className="container">
        <h1>User Registration Form</h1>
        <form className="formcontainer">
          <label htmlFor="userName" className="cartitle">
            Full Name
          </label>
          <div>
            <input
              className="para inputBox"
              type="text"
              id="userName"
              name="userName"
              value={userName.value}
              onChange={(e) =>
                setUserName({ ...userName, value: e.target.value })
              }
              onBlur={() => setUserName({ ...userName, isTouched: true })}
            />
            {!isNameValid(userName.value) && userName.isTouched ? (
              <p className="para message error">
                *Name should be atleast 2 characters long.
              </p>
            ) : (
              <p></p>
            )}
          </div>
          <label htmlFor="dob" className="cartitle">
            Date of Birth
          </label>
          <div>
            <input
              className="para inputBox"
              type="date"
              id="dob"
              name="dob"
              max={maxDate()}
              value={dob.value}
              onChange={(e) => setDob({ ...dob, value: e.target.value })}
              onFocus={() => setDob({ ...dob, isTouched: true })}
            />
            {dob.isTouched && dob.value != "" ? <></> : <></>}
          </div>

          <label htmlFor="email" className="cartitle">
            Email
          </label>
          <div>
            <input
              className="para inputBox"
              type="email"
              id="email"
              name="email"
              value={email.value}
              onChange={(e) => setEmail({ ...email, value: e.target.value })}
              onBlur={() => setEmail({ ...email, isTouched: true })}
            />
            {email.isTouched && !isEmailValid(email.value) ? (
              <p className="para message error">
                *Please provide a valid Email Id
              </p>
            ) : (
              <p></p>
            )}
          </div>

          <label htmlFor="phoneNo" className="cartitle">
            Phone Number
          </label>
          <div>
            <input
              className="para inputBox"
              type="number"
              id="phoneNo"
              name="phoneNo"
              value={phoneNo.value}
              onChange={(e) =>
                setPhoneNo({ ...phoneNo, value: e.target.value })
              }
              onBlur={() => setPhoneNo({ ...phoneNo, isTouched: true })}
            />
            {phoneNo.isTouched && !isPhoneNoValid(phoneNo.value) ? (
              <p className="para message error">
                *Please provide a 9 digit Phone number without country code
              </p>
            ) : (
              <p></p>
            )}
          </div>

          <label htmlFor="gender" className="cartitle">
            Gender
          </label>
          <div className="radioButtons">
            <label htmlFor="male" className="para radio">
              <input
                data-testid="genderOptions"
                type="radio"
                className="para radio"
                id="male"
                value="1"
                name="gender"
                onChange={(e) => setGenderIdHandler(e)}
              />
              Male
            </label>

            <label htmlFor="female" className="para radio">
              <input
                type="radio"
                data-testid="genderOptions"
                className="para radio"
                id="female"
                value="2"
                name="gender"
                onChange={(e) => setGenderIdHandler(e)}
              />
              Female
            </label>

            <label htmlFor="Non-Binary" className="para radio">
              <input
                type="radio"
                data-testid="genderOptions"
                className="para radio"
                id="Non-Binary"
                value="3"
                name="gender"
                onChange={(e) => setGenderIdHandler(e)}
              />
              Non-Binary
            </label>

            <label htmlFor="Not-Specified" className="para radio">
              <input
                type="radio"
                data-testid="genderOptions"
                className="para radio"
                id="Not-Specified"
                value="4"
                name="gender"
                onChange={(e) => setGenderIdHandler(e)}
              />
              Not-Specified
            </label>
          </div>

          <button
            className="button primary buttontxt"
            type="submit"
            disabled={!getIsFormValid()}
            onClick={handleSubmit}
            title={
              !getIsFormValid() ? "Fill in all required details" : undefined
            }
          >
            Submit
          </button>
        </form>
      </div>
    </>
  );
}

export default RegistrationPage;
