package com.example.cinetec.customviews;

import android.content.Context;
import android.net.Uri;
import android.util.AttributeSet;
import android.util.Base64;
import android.util.Log;
import android.util.TypedValue;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.cinetec.R;
import com.example.cinetec.entities.Movie;
import com.example.cinetec.files.StreamUtil;
import com.example.cinetec.network.NetworkCommunicator;
import com.google.android.material.button.MaterialButton;
import com.squareup.picasso.Picasso;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.net.URI;
import java.util.HashMap;
import java.util.Map;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.Response;

public class MovieView extends LinearLayout {

    private AspectRatioImageView cover;
    private LinearLayout layout;
    private Movie movie;
    MaterialButton button;
    private final String movie_images_url="http://25.92.13.1:38389/Images";
    public MovieView(Context context) {
        super(context);
        build(context);
    }

    public MovieView(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
        build(context);
    }

    public MovieView(Context context, @Nullable AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        build(context);
    }

    public MovieView(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr, defStyleRes);
        build(context);


    }
    private void build(Context context){
        View view=LayoutInflater.from(context).inflate(R.layout.view_movie,this);
        cover=(AspectRatioImageView) findViewById(R.id.cover);
        layout=(LinearLayout) findViewById(R.id.movie_image_layout);
        button=(MaterialButton)findViewById(R.id.branch_logo);
        layout.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                //aqui iria la accion correspondiente :v
            }
        });

    }
    public void setMovie(Movie movie){
        this.movie=movie;
        setText(this.movie.getName());
        if(movie.getImage()==null || movie.getImage()=="")return;

        Map<String,String> params=new HashMap<>();
        Log.d("IMPORTANTE",movie.getImage());
        params.put("path",movie.getImage());

        NetworkCommunicator.get(movie_images_url, params, new Callback() {
            @Override
            public void onFailure(@NonNull Call call, @NonNull IOException e) {

            }

            @Override
            public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                Log.d("MOVIES","Llegue al on response");
                Log.d("MOVIES",Boolean.toString(response.isSuccessful()));
                if(!response.isSuccessful())return;
                String fileContent=response.body().source().readUtf8();
                Log.d("MOVIES",fileContent);
                try{
                    JSONObject responseInfo=new JSONObject(fileContent);
                    String stream=responseInfo.getString("fileContents");
                    if(stream=="" || stream==null)return;
                    Log.d("STREAM",stream);
                    InputStream inputStream = new ByteArrayInputStream(Base64.decode(stream.getBytes(), Base64.DEFAULT));
                    File imageFile=StreamUtil.stream2file(inputStream);

                    Picasso.get().load(imageFile).into(cover);

                }
                catch(Exception exception){}




            }
        });




    }
    public void set_cover_size(int width){
        cover.getLayoutParams().width=width;

    }
    public void setText(String text){
        button.setText(text);
    }

    @Override
    public void setOnClickListener(@Nullable OnClickListener l) {
        super.setOnClickListener(l);
        layout.setOnClickListener(l);
    }
}
