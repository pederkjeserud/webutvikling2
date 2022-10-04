<template>

<section class="card mx-auto">
    <article>
        <h3>{{ name }}</h3>
        <img class="card-img" :src="`https://localhost:5001/images/${image}`"/>
        <p>Instrument: {{ instrument }} </p>
        <p>Timepris: {{ pricePerHour }},- NOK</p>
    </article>
</section>
    
</template>

<script>
export default {

    props: {
        id: Number,
        name: String, 
        image: String,
        instrument: String,
        pricePerHour: Number
    }
    
}
</script>

<style scoped>

.card {
  max-width: 400px;
  margin: 20px 10px;
  align-items: center;

}

</style>