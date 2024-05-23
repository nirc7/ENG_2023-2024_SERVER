import logo from './logo.svg';
import './App.css';

const apiUrl = 'https://localhost:7146/api/StudentsRW/';

function App() {

  const btnGetByID = () => {

    console.log('before');

    fetch(apiUrl + 2, {
      method: 'GET',
      headers: new Headers({
        'Content-Type': 'application/json; charset=UTF-8',
        'Accept': 'application/json; charset=UTF-8',
      })
    })
      .then(res => {
        console.log('res=', res);
        console.log('res.status', res.status);
        console.log('res.ok', res.ok);
        return res.json()
      })
      .then(
        (result) => {
          console.log("fetch btnFetchGetStudents= ", result);
          console.log('result.FullName=', result.name);
          // result.map(st => console.log(st.name));
          // console.log('result[0].FullName=', result[0].name);
        },
        (error) => {
          console.log("err post=", error);
        });

    console.log('after');
  }

  const btnGetAll = () => {

    console.log('before');

    fetch(apiUrl + 'all', {
      method: 'GET',
      headers: new Headers({
        'Content-Type': 'application/json; charset=UTF-8',
        'Accept': 'application/json; charset=UTF-8',
      })
    })
      .then(res => {
        console.log('res=', res);
        console.log('res.status', res.status);
        console.log('res.ok', res.ok);
        return res.json()
      })
      .then(
        (result) => {
          console.log("fetch btnFetchGetStudents= ", result);
          result.map(st => console.log(st.name));
          console.log('result[0].FullName=', result[0].name);
        },
        (error) => {
          console.log("err post=", error);
        });

    console.log('after');
  }

  const btnPost = () => {

    const s = { //pay attention case sensitive!!!! should be exactly as the prop in C#!
      ID: 0,
      Name: 'nir',
      Grade: 77
    };

    fetch(apiUrl, {
      method: 'POST',
      body: JSON.stringify(s),
      headers: new Headers({
        'Content-type': 'application/json; charset=UTF-8', //very important to add the 'charset=UTF-8'!!!!
        'Accept': 'application/json; charset=UTF-8',
      })
    })
      .then(res => {
        console.log('res=', res);
        return res.json()
      })
      .then(
        (result) => {
          console.log("fetch POST= ", result);
          console.log(result.grade);
        },
        (error) => {
          console.log("err post=", error);
        });


  }

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <button onClick={btnGetAll}>GetAll</button> <br />
        <button onClick={btnGetByID}>GetById</button> <br />
        <button onClick={btnPost}>Post</button>
      </header>
    </div>
  );
}

export default App;
