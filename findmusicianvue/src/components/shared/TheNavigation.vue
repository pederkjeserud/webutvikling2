<template>
    
  <nav class="navbar">
    <div class="logo">
      <h4><router-link to="/">Find A <span>Musician</span></router-link></h4>
    </div>
    <div class="navbar-links">
      <ul id="nav-ul">
        <li><router-link class="link" to="/">Hjem</router-link></li>
        <li><router-link class="link" to="/artister">Artister</router-link></li>
        <li><router-link class="link" to="/oppdrag">Oppdrag</router-link></li>
        <li><router-link class="link" to="/artist-admin">Artist Admin</router-link></li>
        <li><router-link class="link" to="/oppdrag-admin">Oppdrag Admin</router-link></li>
      </ul>
      <a href="#" class="toggle-button">
        <span class="bar"></span>
        <span class="bar"></span>
        <span class="bar"></span>
      </a>
    </div>
    
  </nav>

  <!-- Denne navigasjonen skulle opprinnelig være mer responsiv og få en hamburgermeny på en viss størrelse. 
      Jeg rakk dessverre ikke å finne ut av hvordan jeg kunne importere scriptet som gjorde dette, og det funker dessverre ikke.
      Derfor er det en del av koden på dette komponentet som ikke funker, men jeg har valgt å la det stående for å vise hvordan jeg hadde tenkt
      I JS-mappen ligger navbar.js som viser script til hamburgermenyen.
   -->
 
</template>



<style scoped>
/* Header and navigation */

:root {
  --navigation: #222222;
  --white: rgb(226, 226, 226);
  --hover-color: rgb(38, 41, 44);
}

.navbar{
    margin-top: 0%;
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.logo a{
  color: black;
    margin-left: 1.3rem;
    font-size: 1.7rem;
    line-height: 60px;
    letter-spacing: 5px;
}

.logo span{
    color: #b50d10;
}

.navbar-links ul {
    display: flex;
    list-style: none;
    margin: 0;
    padding: 0;
}

.navbar-links li {
    margin-right: 0;
}

.link {
    color: var(--white);
    transition: 0.5s;
    padding: 1rem;
    display: block;
}

.navbar-links a:hover{
    background-color: var(--hover-color);
}

.toggle-button {
    position: absolute;
    align-items: center; 
    top: 2.3rem;
    right: 1.3rem;
    display: none;
    flex-direction: column;
    justify-content: space-between;
    width: 30px;
    height: 21px;
    padding: 5px;
    transition: 0.5s;
}

.toggle-button .bar{
    height: 3px;
    width: 100%;
    background-color: var(--white);
    border-radius: 10px;
}
 .toggle-button:hover {
     background-color:var(--hover-color);
 }

 /* @media (max-width: 700px){
    .toggle-button {
        display: flex;   
    }

    .navbar-links{
        display: none;  
        width: 100%; 
    }

    .navbar{
        flex-direction: column;
        align-items: flex-start;
    }

    .navbar-links ul{
        width: 100%;
        flex-direction: column;
    }

    .navbar-links li{
        text-align: center;
    }

    .navbar-links a{
        padding: .5rem 1rem;
    }

    .navbar-links.active{
        display: flex;
    }
} */
</style>