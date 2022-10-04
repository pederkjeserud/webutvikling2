<template>

  <the-navigation></the-navigation>

  <main class="container">
    <router-view></router-view>
  </main>
  

</template>

<script>
import 'bootstrap/dist/css/bootstrap.min.css'
import TheNavigation from './components/shared/TheNavigation'

export default {
  name: 'App',
  components: { TheNavigation }
}

</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

img {
  max-width: 400px;
  margin: auto;
}

.card {
  max-width: 400px;
  margin: auto;
  margin-bottom: 30px;
}

</style>
