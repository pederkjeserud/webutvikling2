<template>

<section class="card mx-auto">
    <article>
        <h3>{{ title }}</h3>
        <p>Type oppdrag: {{ eventType }} </p>
        <p>Pris pr. person {{ maxPrice }},- NOK</p>
        <p>{{ description }} </p>
        <h4>Kontaktinfo</h4>
        <p>Navn: {{ name }}</p>
        <p>Email {{ email }}</p>
        <p>Tlf: {{ phoneNumber }}</p>
    </article>
</section>
    
</template>

<script>
export default {
    props: {
        id: Number,
        title: String, 
        eventType: String,
        maxPrice: Number,
        description: String,
        name: String,
        email: String,
        phoneNumber: String
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