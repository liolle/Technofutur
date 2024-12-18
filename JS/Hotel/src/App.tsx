import type { Component } from 'solid-js';
import BookingForm from './Componnents/BookingForm/BookingForm';
import ToastWrapper from './Componnents/Toast/Toast';

const App: Component = () => {
  return (
    <div class="flex relative justify-center items-center w-full h-screen">
      <BookingForm/>
      <ToastWrapper/>
    </div>
  );
};

export default App;
