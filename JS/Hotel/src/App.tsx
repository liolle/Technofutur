import type { Component } from 'solid-js';
import BookingForm from './Componnents/BookingForm/BookingForm';

const App: Component = () => {
  return (
    <div class="flex justify-center items-center w-full h-screen">
      <BookingForm/>
    </div>
  );
};

export default App;
