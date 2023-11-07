import React from 'react';
import NavBar from './NavBar';
import BackgroundImg from './backgroundMain.png';
function Home(props) {
    return (
        <div className='homePage'>
         <NavBar></NavBar>
         <img src={BackgroundImg} alt='background' width={'100%'}/>
         <div className='carouselText'>
            <p>ChempionsCore</p>
            <p style={{fontSize:'45px',color:'black',marginLeft:'2vw'}}>----ASP.NET API (EntityFrameworkCore)----</p>
         </div>
        </div>
        
    );
}

export default Home;