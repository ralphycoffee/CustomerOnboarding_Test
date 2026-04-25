import { useRef, useState } from "react";
import "./App.css";

function App() {
  const canvasRef = useRef(null);
  const isDrawing = useRef(false);

  const [form, setForm] = useState({
    firstName: "",
    lastName: "",
    email: "",
    phoneNumber: ""
  });

  const [message, setMessage] = useState("");

  const getCanvasPosition = (e) => {
    const canvas = canvasRef.current;
    const rect = canvas.getBoundingClientRect();

    const scaleX = canvas.width / rect.width;
    const scaleY = canvas.height / rect.height;

    return {
      x: (e.clientX - rect.left) * scaleX,
      y: (e.clientY - rect.top) * scaleY
    };
  };

  const startDrawing = (e) => {
    isDrawing.current = true;

    const ctx = canvasRef.current.getContext("2d");
    const position = getCanvasPosition(e);

    ctx.beginPath();
    ctx.moveTo(position.x, position.y);
  };

  const draw = (e) => {
    if (!isDrawing.current) return;

    const ctx = canvasRef.current.getContext("2d");
    const position = getCanvasPosition(e);

    ctx.lineTo(position.x, position.y);
    ctx.stroke();
  };

  const stopDrawing = () => {
    isDrawing.current = false;
  };

  const clearSignature = () => {
    const canvas = canvasRef.current;
    const ctx = canvas.getContext("2d");

    ctx.clearRect(0, 0, canvas.width, canvas.height);
  };

  const submitForm = async (e) => {
    e.preventDefault();

    if (!form.firstName || !form.lastName || !form.email) {
      setMessage("Please complete all required fields.");
      return;
    }

    const signatureBase64 = canvasRef.current.toDataURL("image/png");
    //Change localhost to connect
    const response = await fetch("https://localhost:7109/api/customers", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        ...form,
        signatureBase64
      })
    });

    if (response.ok) {
      setMessage("Customer registered successfully.");

      setForm({
        firstName: "",
        lastName: "",
        email: "",
        phoneNumber: ""
      });

      clearSignature();
    } else {
      setMessage("Registration failed.");
    }
  };

  return (
    <div className="container">
      <h1>Customer Onboarding</h1>

      <form onSubmit={submitForm}>
        <label>First Name:</label>
        <input
          value={form.firstName}
          onChange={(e) => setForm({ ...form, firstName: e.target.value })}
        />

        <label>Last Name:</label>
        <input
          value={form.lastName}
          onChange={(e) => setForm({ ...form, lastName: e.target.value })}
        />

        <label>Email:*</label>
        <input
          value={form.email}
          onChange={(e) => setForm({ ...form, email: e.target.value })}
        />

        <label>Phone Number:</label>
        <input
          value={form.phoneNumber}
          onChange={(e) => setForm({ ...form, phoneNumber: e.target.value })}
        />

        <label>Signature</label>
        <canvas
          ref={canvasRef}
          width="600"
          height="220"
          onMouseDown={startDrawing}
          onMouseMove={draw}
          onMouseUp={stopDrawing}
          onMouseLeave={stopDrawing}
        />

        <div className="buttons">
          <button type="button" onClick={clearSignature}>
            Clear
          </button>

          <button type="submit">
            Register
          </button>
        </div>
      </form>

      <p>{message}</p>
    </div>
  );
}

export default App;