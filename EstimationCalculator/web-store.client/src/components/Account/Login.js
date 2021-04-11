import React, { useState } from "react";
import { ValidateUser } from "../../services/LoginService";
import { setCustomerDetails } from "../../common/token";
import "./login.css";
import {clearToken} from '../../common/token';

const Login = () => {
  clearToken();
  const [loginDetails, setLoginDetails] = useState({
    userName: "",
    userPassword: "",
  });
  const handleInput = (event) => {
    setLoginDetails((prev) => ({
      ...prev,
      [event.target.name]: event.target.value,
    }));
  };
  const signInUser = async (event) => {
    event.preventDefault();
    const details = await ValidateUser(loginDetails);
    setCustomerDetails(details);
    window.location='/estimation/screen';
  };

  return (
    <div className="container bg-secondary login-form">
      <form onSubmit={signInUser} className="form-horizontal">
        <div className="form-group">
          <label className="control-label col-sm-2">Username : </label>
          <input
            className="form-control col-sm-10"
            type="text"
            placeholder="Enter Username"
            name="userName"
            value={loginDetails.userName}
            onChange={handleInput}
            required
          />
        </div>

        <div className="form-group">
          <label className="control-label col-sm-2">Password : </label>
          <input
            className="form-control col-sm-10"
            type="password"
            placeholder="Enter Password"
            name="userPassword"
            value={loginDetails.userPassword}
            onChange={handleInput}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary">
          Login
        </button>
        <button
          type="reset"
          className="btn bg-transparent"
          onClick={() =>
            setLoginDetails({
              userName: "",
              userPassword: "",
            })
          }
          style={{ margin: "5px" }}
        >
          Cancel
        </button>
      </form>
    </div>
  );
};
export default Login;
