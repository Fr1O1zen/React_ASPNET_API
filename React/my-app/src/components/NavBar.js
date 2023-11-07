import React from 'react';
import { NavLink, Route } from 'react-router-dom';

function NavBar(props) {
    return (
        <div>
            <nav className='navBar'>
                <NavLink to="/"><p className='NavText'>ChempionsCoreManagament</p></NavLink>
                <>
               <NavLink className={'navBtn'} to="/Product">Product</NavLink>
               </>
            </nav>
        </div>
    );
}

export default NavBar;